<template>
    <div class="w-full flex px-8">
        <div class="p-4 w-6/12">
            <a class="logo hover" >LOGO</a>
        </div>
        <div class="p-4 w-6/12">
            <div class="w-full flex justify-end">
                <a class="font-semibold hover text-lg px-4">{{ userName }}</a>
                <a class="font-semibold hover text-lg" v-if="isLoggedIn && userName" @click="logout()">Logout</a>
                <a class="font-semibold hover text-lg" v-else @click="login()">Login</a>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: [ 'isLoggedIn', 'userName' ],
        methods: {
            logout() {
                this.$emit('logout');
            },

            login() {
                this.$emit('login')
            }
        }
    }
</script>

<style>
.logo {
    color: #145383;
    font-family: Inter;
    font-size: 32px;
    font-style: normal;
    font-weight: 600;
    line-height: normal;
}
</style>