const express = require("express");
const {
  getAllBooks,
  getBookById,
  addBook,
  updateBook,
  deleteBook,
} = require("./services/bookService");

const app = express();
const PORT = 3000;

app.use(express.json());

// Root
app.get("/", (req, res) => {
  res.json({ message: "Welcome to Book Management API" });
});

// GET all books
app.get("/books", async (req, res) => {
  const books = await getAllBooks();
  res.json(books);
});

// GET book by ID
app.get("/books/:id", async (req, res) => {
  const id = parseInt(req.params.id);
  const book = await getBookById(id);
  if (book) {
    res.json(book);
  } else {
    res.status(404).json({ error: "Book not found" });
  }
});

// POST new book
app.post("/books", async (req, res) => {
  const { title, author } = req.body;
  if (!title || !author) {
    return res.status(400).json({ error: "Title and Author are required" });
  }

  const newBook = { id: Date.now(), title, author };
  await addBook(newBook);
  res.status(201).json(newBook);
});


// PUT update book
app.put("/books/:id", async (req, res) => {
  const id = parseInt(req.params.id);
  const { title, author } = req.body;
  const updatedBook = await updateBook(id, { title, author });
  if (updatedBook) {
    res.json(updatedBook);
  } else {
    res.status(404).json({ error: "Book not found" });
  }
});

// DELETE book
app.delete("/books/:id", async (req, res) => {
  const id = parseInt(req.params.id);
  const success = await deleteBook(id);
  if (success) {
    res.json({ message: "Book deleted" });
  } else {
    res.status(404).json({ error: "Book not found" });
  }
});

// Start server
app.listen(PORT, () => {
  console.log(`🚀 Server running on http://localhost:${PORT}`);
});
