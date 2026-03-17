
function getCart(){return JSON.parse(localStorage.getItem("cart"))||[];}
function saveCart(cart){localStorage.setItem("cart",JSON.stringify(cart));}
function addToCart(product){
let user=localStorage.getItem("user");
if(!user){alert("Please login first");window.location="login.html";return;}
let cart=getCart();cart.push(product);saveCart(cart);alert("Added to Cart");
}
function removeFromCart(i){let cart=getCart();cart.splice(i,1);saveCart(cart);location.reload();}
function cartTotal(){let cart=getCart();let t=0;cart.forEach(p=>t+=p.price);return t;}
