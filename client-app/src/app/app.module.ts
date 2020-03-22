import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AuthorService } from './_services/author.service';
import { HttpClientModule} from '@angular/common/http';
import { NavComponent } from './components/nav/nav.component';
import { AuthorTableComponent } from './components/author-table/author-table.component';
import { AuthorFormComponent } from './components/author-form/author-form.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AuthorTableComponent,
    AuthorFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    FormsModule
  ],
  providers: [AuthorService],
  bootstrap: [AppComponent],
  entryComponents: [AuthorFormComponent]
})
export class AppModule { }
