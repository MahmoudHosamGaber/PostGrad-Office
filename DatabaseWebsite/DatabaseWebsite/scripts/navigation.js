var nav = document.getElementById("nav");
var menu = document.getElementById("menu");
var content = document.querySelector(".main-content");
var navItems = document.querySelector(".nav-items");
var navLinks = document.querySelectorAll(".nav-link");
menu.addEventListener("click", () => {
  if (nav.style.width == "85px") {
    nav.style.width = "300px";
    content.style.marginLeft = "3rem";
    navItems.style.display = "block";
    for (i = 0; i < navLinks.length; i++) {
      navLinks[i].style.display = "block";
    }
  } else {
    nav.style.width = "85px";
    content.style.marginLeft = "-11.25rem";
    for (i = 0; i < navLinks.length; i++) {
      navLinks[i].style.display = "none";
    }
  }
});
