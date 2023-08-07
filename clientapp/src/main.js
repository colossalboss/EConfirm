import Vue from 'vue'
import App from './App.vue'
import msal from 'vue-msal'
// import VueRouter from 'vue-router'

Vue.config.productionTip = false

// Vue.use(VueRouter?);

Vue.use(msal, {
  auth: {
    clientId: '3d463d4b-918a-4659-9a53-0afaf97bee22',
    tenantId: '6ecae75c-75e9-4111-92b0-5cd7afce4ef0',
    authority: 'https://login.microsoftonline.com/6ecae75c-75e9-4111-92b0-5cd7afce4ef0/'
    // clientId: '895b7098-f597-4024-8933-cac99a163db9'
  },
  request: {
    scopes: [ 'api://df296632-e5d6-47ec-9633-1bbeaf417a3f/readaccess' ]
  }
})

new Vue({
  render: h => h(App),
}).$mount('#app')
