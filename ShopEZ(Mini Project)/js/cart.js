$(document).ready(function () {
  //  login check
  let user = localStorage.getItem("user");
  if (!user) {
    alert("Please login first");
    window.location = "login.html";
    return;
  }

  let cart = getCart();
  let html = "";

  cart.forEach((p, i) => {
    // ensure quantity exists
    if (!p.qty) p.qty = 1;

    html += `
<tr>
  <td>${p.name}</td>

  <td>₹${p.price}</td>

  <td>
    <button class="btn btn-sm btn-secondary minus" data-id="${i}">-</button>
    <span class="mx-2">${p.qty}</span>
    <button class="btn btn-sm btn-secondary plus" data-id="${i}">+</button>
  </td>

  <td>₹${p.price * p.qty}</td>

  <td>
    <button class="btn btn-danger btn-sm remove" data-id="${i}">Remove</button>
  </td>
</tr>
`;
  });

  $("#cartItems").html(html);

  $("#total").text(cartTotal());

  //  decrease quantity
  $(".minus").click(function () {
    let i = $(this).data("id");
    let cart = getCart();

    cart[i].qty--;

    if (cart[i].qty <= 0) {
      cart.splice(i, 1);
    }

    localStorage.setItem("cart", JSON.stringify(cart));
    location.reload();
  });

  //  increase quantity
  $(".plus").click(function () {
    let i = $(this).data("id");
    let cart = getCart();

    cart[i].qty++;

    localStorage.setItem("cart", JSON.stringify(cart));
    location.reload();
  });

  //  remove item
  $(".remove").click(function () {
    removeFromCart($(this).data("id"));
  });
});
