import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Author } from 'src/app/_models/Author';
import { AuthorService } from 'src/app/_services/author.service';


@Component({
  selector: 'app-author-form',
  templateUrl: './author-form.component.html',
  styleUrls: ['./author-form.component.css']
})

export class AuthorFormComponent implements OnInit {
  authors: Author[];
  name: string;
  flagButton: boolean;
  count: string;
  countArray: number[];
  hasErrors: boolean;

  constructor(public activeModal: NgbActiveModal, private authorService: AuthorService) {}

  ngOnInit() {
  }

  changes() {
    this.countArray = new Array(+this.count)
        .fill(0).map((x, i) => i);

    if(this.countArray.length > 0){
      this.flagButton = true;
    } else {
      this.flagButton = false;
    }
  }

  createAuthors(authorsForm) {
    const namesForm = authorsForm.form.value.inputs;
    this.authors = new Array();

    for (const value in namesForm) {
      if (namesForm.hasOwnProperty(value)) {
        if (!namesForm[value]) {
          alert('Preencha todos os campos.');
          this.hasErrors = true;
          break;
        }

        this.hasErrors = false;
        this.authors.push({ name: namesForm[value] });
      }
    }

    if(!this.hasErrors){
      this.authorService.createAuthors(this.authors).subscribe(() => {
        this.activeModal.close();
      }, error => {
        console.log(error);
      });
    }
  }

  public inputNameValidator(event: any) {
    const pattern = /^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/;
    if (!pattern.test(event.target.value)) {
      event.target.value = event.target.value.replace(/[^a-zA-Z ]/g, '');
    }
  }
}
