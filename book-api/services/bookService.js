const fs = require("fs").promises;
const EventEmitter = require("events");
const path = require("path");

const filePath = path.join(__dirname, "../data/books.json");

// Event emitter for logging
class BookEmitter extends EventEmitter {}
const bookEmitter = new BookEmitter();

bookEmitter.on("bookAdded", () => console.log("📗 Book Added"));
bookEmitter.on("bookUpdated", () => console.log("✏️ Book Updated"));
bookEmitter.on("bookDeleted", () => console.log("❌ Book Deleted"));

// Utility functions
async function readBooks() {
  try {
    const data = await fs.readFile(filePath, "utf8");
    return JSON.parse(data || "[]");
  } catch (err) {
    console.error("Error reading file:", err);
    return [];
  }
}

async function writeBooks(books) {
  try {
    await fs.writeFile(filePath, JSON.stringify(books, null, 2));
  } catch (err) {
    console.error("Error writing file:", err);
  }
}

async function getAllBooks() {
  return await readBooks();
}

async function getBookById(id) {
  const books = await readBooks();
  return books.find((b) => b.id === id);
}

async function addBook(book) {
  const books = await readBooks();
  books.push(book);
  await writeBooks(books);
  bookEmitter.emit("bookAdded");
}

async function updateBook(id, updatedBook) {
  let books = await readBooks();
  const index = books.findIndex((b) => b.id === id);
  if (index !== -1) {
    books[index] = { ...books[index], ...updatedBook };
    await writeBooks(books);
    bookEmitter.emit("bookUpdated");
    return books[index];
  }
  return null;
}

async function deleteBook(id) {
  let books = await readBooks();
  const newBooks = books.filter((b) => b.id !== id);
  if (newBooks.length !== books.length) {
    await writeBooks(newBooks);
    bookEmitter.emit("bookDeleted");
    return true;
  }
  return false;
}

module.exports = {
  getAllBooks,
  getBookById,
  addBook,
  updateBook,
  deleteBook,
};
