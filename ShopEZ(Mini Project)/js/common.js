function getCart() {
  return JSON.parse(localStorage.getItem("cart")) || [];
}
function saveCart(cart) {
  localStorage.setItem("cart", JSON.stringify(cart));
}
function addToCart(product) {
  let user = localStorage.getItem("user");

  if (!user) {
    alert("Please login first");
    window.location = "login.html";
    return;
  }

  let cart = getCart();

  let existing = cart.find((item) => item.id === product.id);

  if (existing) {
    existing.qty += 1;
  } else {
    product.qty = 1;
    cart.push(product);
  }

  localStorage.setItem("cart", JSON.stringify(cart));

  alert("Added to cart");
}
function removeFromCart(i) {
  let cart = getCart();
  cart.splice(i, 1);
  saveCart(cart);
  location.reload();
}
function cartTotal() {
  let cart = getCart();
  let total = 0;

  cart.forEach((p) => {
    total += p.price * (p.qty || 1);
  });

  return total;
}
