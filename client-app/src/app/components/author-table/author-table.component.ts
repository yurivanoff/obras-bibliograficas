import { Component, OnInit } from '@angular/core';
import { AuthorFormComponent } from '../author-form/author-form.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { Author } from 'src/app/_models/Author';
import { AuthorService } from 'src/app/_services/author.service';

@Component({
  selector: 'app-author-table',
  templateUrl: './author-table.component.html',
  styleUrls: ['./author-table.component.css']
})

export class AuthorTableComponent implements OnInit {
  authors: Author[];

  constructor(private authorService: AuthorService, private modalService: NgbModal) { }

  ngOnInit() {
    this.authorService.getAuthors().subscribe(response => {
      this.authors = response;
    }, error => {
      console.log(error);
    });
  }

  removeAuthor(id: number) {
    this.authorService.deleteAuthors(id).subscribe(response => {
      this.ngOnInit();
    }, error => {
      console.log(error);
    });
  }

  openModal() {
    const modal = this.modalService.open(AuthorFormComponent);

    modal.result.then(() => {
        this.ngOnInit();
    });
  }
}
