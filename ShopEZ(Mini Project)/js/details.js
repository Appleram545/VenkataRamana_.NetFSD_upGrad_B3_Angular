$(document).ready(function () {

  let id = new URLSearchParams(window.location.search).get("id");


  $.getJSON("data/products.json", function (products) {
    let p = products.find((x) => x.id == id);

    if (!p) return;

    $("#pImg").attr("src", p.image);
    $("#pName").text(p.name);
    $("#pDesc").text(p.description || "No description available");
    $("#pPrice").text("₹" + p.price);

    $("#addCart").click(function () {
      addToCart(p);
    });
  });
});
