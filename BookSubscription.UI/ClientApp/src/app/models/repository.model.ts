import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Book } from "./book.model";

const bookUrl = "https://localhost:44344/api/Books/";

@Injectable()
export class Repository{
    bookData: Book;
    books: Book[];

    constructor(private http: HttpClient){
        this.getBooks();
    }

    getBooks(){
        this.http.get<Book[]>(bookUrl)
        .subscribe(s => this.books = s);
    }

    getBook(id: string){
        this.http.get<Book>(bookUrl + id)
            .subscribe(b => this.bookData = b);
    }
}