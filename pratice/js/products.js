
$(document).ready(function(){
$.getJSON("data/products.json",function(products){
let html="";
products.forEach(p=>{
html+=`
<div class="col-md-3 mb-4">
<div class="card h-100">
<img src="${p.image}" class="card-img-top">
<div class="card-body">
<h6>${p.name}</h6>
<p>₹${p.price}</p>
<button class="btn btn-dark btn-sm addCart" data-id="${p.id}">Add to Cart</button>
</div>
</div>
</div>`;
});
$("#productList").html(html);
$(".addCart").click(function(){
let id=$(this).data("id");
let product=products.find(p=>p.id==id);
addToCart(product);
});
});
});
