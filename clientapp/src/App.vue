<template>
  <div id="app">
    <!-- <div id="overlay">Hello</div> -->
    <Navbar @logout="logout()" @login="login()" :isLoggedIn="isLoggedIn" :userName="userName" />
    <div class="w-full flex justify-center items-center" style="height: 80vh;" v-if="loading">
      <AppLoading />
    </div>
    <div class="w-full" v-else>
      <div class="w-full px-4 mb-4">
        <div class="w-full px-8 text-center my-4 flex justify-between">
          <span>
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
              <path d="M9.57 5.93018L3.5 12.0002L9.57 18.0702M20.5 12.0002H3.67" stroke="black" stroke-width="1.5"
                stroke-miterlimit="10" stroke-linecap="round" stroke-linejoin="round" />
            </svg>
          </span>
          <h1 class="bold text-xl title">Probation Evaluation Form</h1>
          <span></span>
        </div>
      </div>
      <div class="w-full main-container">
        <!-- <router-view></router-view> -->
        <EvaluationForm />
        <ManagerReview />
        <StaffAcknowledgement />
        <CeoComment />
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue'
import EvaluationForm from './views/EvaluationForm.vue'
import ManagerReview from './views/LineManagerReview.vue'
import StaffAcknowledgement from './views/StaffAcknowledgement.vue'
import CeoComment from './views/CeoComment.vue'
import AppLoading from './components/AppLoading.vue'
// import { msalInstance } from "vue-msal-browser"
import * as Msal from "msal";

export default {
  name: 'app',
  components: {
    Navbar,
    EvaluationForm,
    ManagerReview,
    StaffAcknowledgement,
    CeoComment,
    AppLoading
  },

  data() {
    return {
      loading: false,
      userEmail: '',
      userName: '',
      isLoggedIn: false,
      msalConfig: {
        auth: {
          // clientId: '895b7098-f597-4024-8933-cac99a163db9',
          clientId: '3d463d4b-918a-4659-9a53-0afaf97bee22',
          // tenantId: '6ecae75c-75e9-4111-92b0-5cd7afce4ef0',
          authority: 'https://login.microsoftonline.com/6ecae75c-75e9-4111-92b0-5cd7afce4ef0/'
        }
      }
    }
  },

  methods: {
    /* eslint no-console: "warn" */
    logout() {
      this.isLoggedIn = false;
      this.userName = '';
      this.userEmail = '';
      localStorage.removeItem('mstoken');
    },

    login() {
      this.signIn();
    },

    signIn() {
      /* eslint no-console: "warn" */
      this.loading = true;
      const msalInstance = new Msal.UserAgentApplication(this.msalConfig);


      // msalInstance.handleRedirectCallback((error, response) => {
      //   // handle redirect response or error
      //   console.log(response, "response");
      //   console.log(error, "error");
      // });

      // let loginRequest = {
      //   scopes: ['api://df296632-e5d6-47ec-9633-1bbeaf417a3f/readaccess'] // optional Array<string>
      // };

      // msalInstance.loginPopup(loginRequest)
      //   .then(response => {
      //     // handle response
      //     console.log(response, "response in pop");
      //   })
      //   .catch(err => {
      //     // handle error
      //     console.log(err, "error in pop");
      //   });

      var tokenRequest = {
        scopes: ['api://df296632-e5d6-47ec-9633-1bbeaf417a3f/readaccess']
      };

      msalInstance.acquireTokenSilent(tokenRequest)
        .then(response => {
          // get access token from response
          // response.accessToken
          alert('acquired token' + response.accessToken)
          //console.log(response, "response in silent");
          this.setUserDetails(response);
          if (response.accessToken) return true;
        })
        .catch(err => {
          // could also check if err instance of InteractionRequiredAuthError if you can import the class.
          alert('could not get token' + err.name)
          //console.log(err, "error in silent top");
          return msalInstance.loginPopup(tokenRequest)
            .then(response => {
              // get access token from response
              // response.accessToken
              alert('acquired token on second try' + response.accessToken)
              
              //console.log(response, "response in acquire pop");
              msalInstance.acquireTokenSilent(tokenRequest)
                .then(response => {
                  // get access token from response
                  // response.accessToken
                  alert('acquired token after login popup')
                  //console.log(response, "response in silent");
                  this.setUserDetails(response);
                  this.loading = false;
                })
                .catch(err => {
                  alert('failed after login popup' + err.name)
                  this.loading = false;
                  //console.log(err, 'err after login popup');
                })
            })
            .catch(err => {
              // handle error
              alert('failed again' + err.name)
              //console.log(err, "error in acquire pop");
              this.loading = false;
            });
          // }
        });
    },

    setUserDetails(response) {
      this.userEmail = response.account.userName;
      this.userName = response.account.name;
      this.isLoggedIn = true;
      localStorage.setItem('mstoken', response.accessToken);
      this.loading = false;
    }
  },

  created() {
    
  }
}
</script>

<style>
* {
  font-family: Roboto;
}

h1 {
  font-family: Inter;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  background: #F6FAFA;
  min-height: 100vh;
}

.title {
  color: #000;
  font-size: 32px;
  font-style: normal;
  font-weight: 400;
  line-height: normal;
  font-family: Inter;
}

.main-container {
  max-width: 1440px;
  margin-left: auto;
  margin-right: auto;
}

#overlay {
  position: fixed;
  /* Sit on top of the page content */
  display: block;
  /* Hidden by default */
  width: 100%;
  /* Full width (cover the whole page) */
  height: 100%;
  /* Full height (cover the whole page) */
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  /* Black background with opacity */
  z-index: 2;
  /* Specify a stack order in case you're using a different order for other elements */
  cursor: pointer;
  /* Add a pointer on hover */
}
</style>
