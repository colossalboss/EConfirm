import { createRouter, createWebHistory } from 'vue-router'
import EvaluationForm from '../views/EvaluationForm.vue'
const routes = [
  {
    path: '/',
    name: 'EvaluationForm',
    component: EvaluationForm
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/EvaluationForm.vue')
  }
]
const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})
export default router