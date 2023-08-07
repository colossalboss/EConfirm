<template>
  <div id="app">
    <Navbar />
    <router-view></router-view>
  </div>
  
</template>

<script>
import Navbar from './components/Navbar.vue'
// import { msalInstance } from "vue-msal-browser"
import * as Msal from "msal";

export default {
  name: 'app',
  components: {
    Navbar
  },

  data() {
    return {
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
    signIn() {
      /* eslint no-console: "warn" */
      console.log('signing');
      const msalInstance = new Msal.UserAgentApplication(this.msalConfig);


      msalInstance.handleRedirectCallback((error, response) => {
        // handle redirect response or error
        console.log(response, "response");
        console.log(error, "error");
      });

      let loginRequest = {
       scopes: ['api://df296632-e5d6-47ec-9633-1bbeaf417a3f/readaccess'] // optional Array<string>
      };

        msalInstance.loginPopup(loginRequest)
          .then(response => {
              // handle response
              console.log(response, "response in pop");
          })
          .catch(err => {
              // handle error
              console.log(err, "error in pop");
          });

          var tokenRequest = {
            scopes: ['api://df296632-e5d6-47ec-9633-1bbeaf417a3f/readaccess']
        };

        msalInstance.acquireTokenSilent(tokenRequest)
            .then(response => {
                // get access token from response
                // response.accessToken
                console.log(response, "response in silent");
            })
            .catch(err => {
                // could also check if err instance of InteractionRequiredAuthError if you can import the class.
                console.log(err, "error in silent top");
                if (err.name === "InteractionRequiredAuthError") {
                    return msalInstance.acquireTokenPopup(tokenRequest)
                        .then(response => {
                            // get access token from response
                            // response.accessToken
                            console.log(response, "response in acquire pop");
                        })
                        .catch(err => {
                            // handle error
                            console.log(err, "error in acquire pop");
                        });
                }
            });
        }
  },

  created() {
    /* eslint no-console: "warn" */
    console.log(this.$msal, "msal status");
    // if (!this.$msal.isAuthenticated()) {
    //   console.log('login');
    //   this.$msal.signIn()
    //   console.log(this.$msal, "msal after");
    // }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  background: #F6FAFA;
  min-height: 100vh;
}
</style>
