using ContactManagement.Models;
using ContactManagement.Services;

var service = new ContactService();

service.AddContact(new Contact
{
    Id = 1,
    Name = "Ram",
    Email = "ram@test.com",
    Phone = "9999999999"
});

var contacts = service.GetAllContacts();

foreach (var contact in contacts)
{
    Console.WriteLine($"{contact.Id} - {contact.Name}");
}