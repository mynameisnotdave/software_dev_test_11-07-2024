public class Main {
    public static void main(String[] args) {
        Library library = new Library();
        library.loadBooksFromJson("books_seed_data.json");
        System.out.println("Total books in library: " + library.getTotalBooks());
    }
}