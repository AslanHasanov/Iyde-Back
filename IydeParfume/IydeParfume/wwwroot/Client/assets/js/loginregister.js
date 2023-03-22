
let login=document.getElementById("log")
let register=document.getElementById("reg")
let loginShow=document.querySelector(".log")
let registerShow=document.querySelector(".reg")

login.onclick= function(){
    login.style.opacity="1"
    register.style.opacity="0.35"
}
register.onclick= function(){
    register.style.opacity="1"
    login.style.opacity="0.35"
}