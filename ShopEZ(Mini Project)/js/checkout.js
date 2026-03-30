$(document).ready(function () {
  let user = localStorage.getItem("user");
  if (!user) {
    alert("Please login first");
    window.location = "login.html";
    return;
  }
  let cart = getCart();
  if (cart.length === 0) {
    alert("Cart is empty");
    window.location = "products.html";
    return;
  }
  let html = "";
  cart.forEach((p) => {
    html += ` <li class="list-group-item d-flex justify-content-between"> <span>${p.name}</span> <span>₹${p.price}</span> </li> `;
  });
  $("#summary").html(html);
  $("#total").text(cartTotal());
  $("#checkoutForm").submit(function (e) {
    e.preventDefault();
    alert("🎉 Order placed successfully!");
    localStorage.removeItem("cart");
    window.location = "index.html";
  });
});
