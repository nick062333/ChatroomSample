export default{
    //透過啟用這個選項，Vuex 會自動幫你在 module 的 actions / mutations / getters 加上 namespace 的 prefix
    namespaced: true,
    state:{
        token: "",
        isLogin: false
    },

    //更改 Vuex 的 store 中的状态的唯一方法是提交 mutation。Vuex 中的 mutation 非常类似于事件：每个 mutation 都有一个字符串的事件类型 (type)和一个回调函数 (handler)
    mutations:{
        SET_AUTH(state, options){
            state.token = options.token;
            state.isLogin = options.isLogin;
        }
    },
    //Action 提交的是 mutation，而不是直接变更状态
    //Action 可以包含任意异步操作
    actions:{
        setAuth(context, options){
            context.commit('SET_AUTH',{
                token: options.token,
                isLogin: options.isLogin
            })
        }
    }
}