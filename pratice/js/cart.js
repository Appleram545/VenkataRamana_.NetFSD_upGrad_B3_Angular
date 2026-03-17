
$(document).ready(function(){
let user=localStorage.getItem("user");
if(!user){alert("Please login first");window.location="login.html";return;}
let cart=getCart();let html="";
cart.forEach((p,i)=>{
html+=`<tr><td>${p.name}</td><td>₹${p.price}</td>
<td><button class="btn btn-danger btn-sm remove" data-id="${i}">Remove</button></td></tr>`;
});
$("#cartItems").html(html);
$("#total").text(cartTotal());
$(".remove").click(function(){removeFromCart($(this).data("id"));});
});
