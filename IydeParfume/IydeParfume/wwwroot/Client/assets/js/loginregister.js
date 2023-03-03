
let login=document.getElementById("log")
let register=document.getElementById("reg")
let loginShow=document.querySelector(".log")
let registerShow=document.querySelector(".reg")

login.onclick= function(){
    loginShow.classList.remove("d-none");
    registerShow.classList.add("d-none");
    login.style.opacity="1"
    register.style.opacity="0.35"
}
register.onclick= function(){
    registerShow.classList.remove("d-none");
    loginShow.classList.add("d-none");
    register.style.opacity="1"
    login.style.opacity="0.35"
}