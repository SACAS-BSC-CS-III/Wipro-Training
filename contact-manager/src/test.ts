import { Contact } from "./interfaces/contact";
import { ContactManager } from "./classes/contact-manager";

const manager = new ContactManager();

// 1. Add contacts
manager.addContact({ id: 1, name: "Alice", email: "alice@mail.com", phone: "1234567890" });
manager.addContact({ id: 2, name: "Bob", email: "bob@mail.com", phone: "9876543210" });
manager.addContact({ id: 1, name: "Duplicate", email: "dup@mail.com", phone: "1111111111" }); // error

// 2. View contacts
console.log("📒 Contact List:", manager.viewContacts());

// 3. Modify contact
manager.modifyContact(2, { phone: "5555555555" });
manager.modifyContact(3, { name: "Ghost" }); // error

// 4. Delete contact
manager.deleteContact(1);
manager.deleteContact(99); // error

// 5. Final list
console.log("📒 Final Contact List:", manager.viewContacts());
