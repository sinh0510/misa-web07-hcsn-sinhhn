import { createApp } from 'vue'
import App from './App.vue'
import {createRouter, createWebHistory} from 'vue-router'
import EmployeeList from './view/EmployeeList.vue'
import CustomerList from './view/CustomerList.vue'
import VueDateFns from "vue-date-fns";
//Khai báo router
const routes= [
    {path: "/employee", component: EmployeeList},
    {path: "/customer", component: CustomerList},
]
//Khởi tạo router
const vueRouter = createRouter({
    history: createWebHistory(),
    routes: routes
})
// Sử dụng
createApp(App).use(vueRouter).mount('#app')



App.use(VueDateFns);