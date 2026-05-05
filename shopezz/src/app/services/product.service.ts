import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of, BehaviorSubject } from "rxjs";
import { Product } from "../models/product";
import { environment } from "../../environments/environment";

@Injectable({ providedIn: "root" })
export class ProductService {
  private apiUrl = `${environment.apiUrl}/product`;

  private mockProducts: Product[] = [
    {
      id: 2001,
      name: "Sony WH-1000XM5",
      description:
        "Industry-leading noise cancellation, 30hr battery, crystal clear audio.",
      price: 24999,
      imageUrl:
        "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=400",
      category: "Headphones",
      stock: 15,
    },
    {
      id: 2002,
      name: "Apple AirPods Pro 2nd Gen",
      description:
        "Active noise cancellation, transparency mode and spatial audio.",
      price: 19999,
      imageUrl:
        "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434?w=400",
      category: "Headphones",
      stock: 20,
    },
    {
      id: 2003,
      name: "JBL Tune 760NC",
      description:
        "Wireless over-ear headphones with ANC and 35hr battery life.",
      price: 5999,
      imageUrl:
        "https://images.unsplash.com/photo-1484704849700-f032a568e944?w=400",
      category: "Headphones",
      stock: 25,
    },
    {
      id: 2004,
      name: "iPhone 15 Pro Max",
      description:
        "A17 Pro chip, titanium design, 48MP camera with 5x optical zoom.",
      price: 134900,
      imageUrl:
        "https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=400",
      category: "Smartphones",
      stock: 10,
    },
    {
      id: 2005,
      name: "Samsung Galaxy S24 Ultra",
      description:
        "Snapdragon 8 Gen 3, 200MP camera, built-in S Pen and AI features.",
      price: 129999,
      imageUrl:
        "https://images.unsplash.com/photo-1706439154236-f5a4b0763d61?w=400",
      category: "Smartphones",
      stock: 8,
    },
    {
      id: 2006,
      name: "OnePlus 12",
      description:
        "Snapdragon 8 Gen 3, Hasselblad camera, 100W SUPERVOOC charging.",
      price: 64999,
      imageUrl:
        "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=400",
      category: "Smartphones",
      stock: 15,
    },
    {
      id: 2007,
      name: 'MacBook Pro 14" M3 Pro',
      description:
        "Apple M3 Pro chip, Liquid Retina XDR display, 18hr battery.",
      price: 199900,
      imageUrl:
        "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=400",
      category: "Laptops",
      stock: 8,
    },
    {
      id: 2008,
      name: "Dell XPS 15 OLED",
      description: "Intel Core i9, RTX 4070, 3.5K OLED touchscreen display.",
      price: 159999,
      imageUrl:
        "https://images.unsplash.com/photo-1593642632559-0c6d3fc62b89?w=400",
      category: "Laptops",
      stock: 6,
    },
    {
      id: 2009,
      name: "ASUS ROG Zephyrus G14",
      description:
        "AMD Ryzen 9, RTX 4060, AniMe Matrix LED lid, 120Hz display.",
      price: 119999,
      imageUrl:
        "https://images.unsplash.com/photo-1525547719571-a2d4ac8945e2?w=400",
      category: "Laptops",
      stock: 10,
    },
    {
      id: 2100,
      name: 'iPad Pro 12.9" M2',
      description:
        "Apple M2 chip, Liquid Retina XDR, Thunderbolt 4, 5G connectivity.",
      price: 99900,
      imageUrl:
        "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=400",
      category: "Tablets",
      stock: 10,
    },
    {
      id: 2011,
      name: "Samsung Galaxy Tab S9 Ultra",
      description:
        '14.6" AMOLED, Snapdragon 8 Gen 2, S Pen included, IP68 rated.',
      price: 89999,
      imageUrl:
        "https://images.unsplash.com/photo-1589739900243-4b52cd9b104e?w=400",
      category: "Tablets",
      stock: 8,
    },
    {
      id: 2012,
      name: "Apple Watch Series 9",
      description:
        "S9 chip, double tap gesture, always-on Retina display, health sensors.",
      price: 41900,
      imageUrl:
        "https://images.unsplash.com/photo-1434493789847-2f02dc6ca35d?w=400",
      category: "Smartwatches",
      stock: 20,
    },
    {
      id: 2013,
      name: "Samsung Galaxy Watch 6 Classic",
      description:
        "Rotating bezel, advanced health tracking, sleep coaching, BIA sensor.",
      price: 34999,
      imageUrl:
        "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=400",
      category: "Smartwatches",
      stock: 15,
    },
    {
      id: 2014,
      name: "Sony Alpha A7 IV",
      description:
        "33MP full-frame mirrorless, 4K60 video, real-time eye AF, 10fps burst.",
      price: 219990,
      imageUrl:
        "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?w=400",
      category: "Cameras",
      stock: 5,
    },
    {
      id: 2015,
      name: "GoPro Hero 12 Black",
      description:
        "5.3K60 video, HyperSmooth 6.0, waterproof to 10m, enduro battery.",
      price: 34999,
      imageUrl:
        "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=400",
      category: "Cameras",
      stock: 12,
    },
    {
      id: 2016,
      name: "PlayStation 5 Slim",
      description:
        "Custom AMD CPU & GPU, 4K 120fps, ray tracing, ultra-high speed SSD.",
      price: 54990,
      imageUrl:
        "https://images.unsplash.com/photo-1607853202273-797f1c22a38e?w=400",
      category: "Gaming",
      stock: 8,
    },
    {
      id: 2017,
      name: "Xbox Series X",
      description:
        "12 teraflops GPU, 4K 60fps up to 120fps, Quick Resume, Game Pass.",
      price: 49990,
      imageUrl:
        "https://images.unsplash.com/photo-1621259182978-fbf93132d53d?w=400",
      category: "Gaming",
      stock: 10,
    },
    {
      id: 2018,
      name: 'LG UltraGear 27" 4K 144Hz',
      description:
        "4K Nano IPS, 1ms response, G-Sync compatible, VESA DisplayHDR 600.",
      price: 54999,
      imageUrl:
        "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=400",
      category: "Monitors",
      stock: 10,
    },
    {
      id: 2019,
      name: "JBL Charge 5",
      description:
        "Portable waterproof speaker, 20hr battery, powerbank feature, PartyBoost.",
      price: 11999,
      imageUrl:
        "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=400",
      category: "Speakers",
      stock: 25,
    },
    {
      id: 2020,
      name: "Logitech MX Master 3S",
      description:
        "Advanced wireless mouse, 8K DPI, quiet clicks, MagSpeed scroll, USB-C.",
      price: 7999,
      imageUrl:
        "https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?w=400",
      category: "Accessories",
      stock: 22,
    },
  ];

  private productsSubject = new BehaviorSubject<Product[]>(this.mockProducts);

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    
    return this.productsSubject.asObservable();
  }

  getProduct(id: number): Observable<Product | undefined> {
   
    return of(this.productsSubject.value.find((p) => p.id === id));
  }

  addProduct(product: Omit<Product, "id">): Observable<Product> {
    const newProduct = { ...product, id: Date.now() };
    this.productsSubject.next([...this.productsSubject.value, newProduct]);
    return of(newProduct);
  }

  updateProduct(id: number, product: Product): Observable<Product> {
    const updated = this.productsSubject.value.map((p) =>
      p.id === id ? product : p,
    );
    this.productsSubject.next(updated);
    return of(product);
  }

  deleteProduct(id: number): Observable<void> {
    this.productsSubject.next(
      this.productsSubject.value.filter((p) => p.id !== id),
    );
    return of(undefined);
  }
}
