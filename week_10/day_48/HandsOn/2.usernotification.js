"use strict";
function getWelcomeMessage(name) {
    return `Welcome, ${name}!`;
}
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `${name} is ${age} years old`;
    }
    return `${name}'s age is not provided`;
}
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed ? `${name} is subscribed` : `${name} is not subscribed`;
}
function isEligibleForPremium(age) {
    return age > 18;
}
const getAlertMessage = (message) => {
    return `Alert: ${message}`;
};
const NotificationService = {
    appName: "Amazon",
    sendNotification: (user) => {
        return `Hello ${user}, welcome to ${NotificationService.appName}`;
    },
};
console.log(getWelcomeMessage("Ram"));
console.log(getUserInfo("Ram", 25));
console.log(getUserInfo("Ram"));
console.log(getSubscriptionStatus("Ram", true));
console.log(getSubscriptionStatus("Ram"));
console.log("Eligible:", isEligibleForPremium(20));
console.log(getAlertMessage("Your account is updated"));
console.log(NotificationService.sendNotification("Ram"));
