$(document).ready(function () {
  $.getJSON("data/products.json", function (products) {
    let html = "";
    products.forEach((p) => {
  html += `
<div class="col-6 col-md-4 col-lg-3 mb-4">
  <div class="card h-100">
    <img src="${p.image}" class="card-img-top">

    <div class="card-body">
      <h6>${p.name}</h6>
      <p>₹${p.price}</p>

      <a href="product-details.html?id=${p.id}" class="btn btn-sm btn-outline-primary">View</a>

      <button onclick='addToCart(${JSON.stringify(p)})'
        class="btn btn-sm btn-dark mt-2">Add to Cart</button>
    </div>
  </div>
</div>
`;
    });
    $("#productList").html(html);
    $(".addCart").click(function () {
      let id = $(this).data("id");
      let product = products.find((p) => p.id == id);
      addToCart(product);
    });
  });
});
