import { Contact } from "../interfaces/contact";

export class ContactManager {
    private contacts: Contact[] = [];

    // Add new contact
    addContact(contact: Contact): void {
        const exists = this.contacts.find(c => c.id === contact.id);
        if (exists) {
            console.log(`❌ Contact with ID ${contact.id} already exists.`);
            return;
        }
        this.contacts.push(contact);
        console.log(`✅ Contact "${contact.name}" added successfully.`);
    }

    // View all contacts
    viewContacts(): Contact[] {
        if (this.contacts.length === 0) {
            console.log("⚠️ No contacts found.");
        }
        return this.contacts;
    }

    // Modify existing contact
    modifyContact(id: number, updatedContact: Partial<Contact>): void {
        const index = this.contacts.findIndex(c => c.id === id);
        if (index === -1) {
            console.log(`❌ Contact with ID ${id} not found.`);
            return;
        }
        this.contacts[index] = { ...this.contacts[index], ...updatedContact };
        console.log(`✏️ Contact with ID ${id} modified successfully.`);
    }

    // Delete a contact
    deleteContact(id: number): void {
        const index = this.contacts.findIndex(c => c.id === id);
        if (index === -1) {
            console.log(`❌ Contact with ID ${id} not found.`);
            return;
        }
        const removed = this.contacts.splice(index, 1);
        console.log(`🗑️ Contact "${removed[0].name}" deleted successfully.`);
    }
}
