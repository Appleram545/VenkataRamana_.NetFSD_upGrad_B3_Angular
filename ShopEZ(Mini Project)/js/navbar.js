$(document).ready(function () {
  let user = localStorage.getItem("user");
  let auth = user
    ? `<li class="nav-item"><span class="nav-link text-warning">Hello ${user}</span></li>
<li class="nav-item"><a class="nav-link" href="#" id="logoutBtn">Logout</a></li>`
    : `<li class="nav-item"><a class="nav-link" href="login.html">Login</a></li>`;

  let nav = `
<nav class="navbar navbar-expand-lg navbar-dark bg-dark sticky-top">
<div class="container">
<a class="navbar-brand" href="index.html">ShopEZ</a>
<button class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#menu"><span class="navbar-toggler-icon"></span></button>
<div class="collapse navbar-collapse" id="menu">
<ul class="navbar-nav ms-auto">
<li class="nav-item"><a class="nav-link" href="index.html">Home</a></li>
<li class="nav-item"><a class="nav-link" href="products.html">Products</a></li>
<li class="nav-item"><a class="nav-link" href="cart.html">Cart</a></li>
${auth}
</ul>
</div>
</div>
</nav>`;

  $("#navbar").html(nav);
  $("#logoutBtn").click(function () {
    localStorage.removeItem("user");
    location.reload();
  });
});
