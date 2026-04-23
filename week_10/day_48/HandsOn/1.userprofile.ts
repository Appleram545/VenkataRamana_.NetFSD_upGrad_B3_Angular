
const userName: string = "Ram";
let age: number = 25;
const email: string = "ram4@gmail.com";
const isSubscribed: boolean = true;


let city = "Hyderabad";  
let score = 100;         


age = age + 1;


const userMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;


const isEligibleForPremium: boolean = age > 18 && isSubscribed;


console.log(userMessage);
console.log("City:", city);
console.log("Score:", score);
console.log("Updated Age:", age);
console.log("Is Eligible for Premium:", isEligibleForPremium);