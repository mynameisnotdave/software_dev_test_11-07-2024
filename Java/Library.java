// Library.java
import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Library {
    private List<Book> books = new ArrayList<>();

    public void addBook(Book book) {
        books.add(book);
    }

    public Book findBookByISBN(String isbn) {
        return books.stream()
                .filter(book -> book.getIsbn().equals(isbn))
                .findFirst()
                .orElse(null);
    }

    public List<Book> findBooksByAuthor(String author) {
        return books.stream()
                .filter(book -> book.getAuthor().toLowerCase().contains(author.toLowerCase()))
                .collect(Collectors.toList());
    }

    public int getTotalBooks() {
        return books.size();
    }

    public void loadBooksFromJson(String jsonFilePath) {
        ObjectMapper objectMapper = new ObjectMapper();
        try {
            Book[] loadedBooks = objectMapper.readValue(new File(jsonFilePath), Book[].class);
            for (Book book : loadedBooks) {
                addBook(book);
            }
            System.out.println("Successfully loaded " + loadedBooks.length + " books from JSON.");
        } catch (IOException e) {
            System.err.println("Error loading books from JSON: " + e.getMessage());
        }
    }
}