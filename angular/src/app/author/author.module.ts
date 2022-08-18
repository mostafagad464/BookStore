import { NgModule } from '@angular/core';

import { AuthorRoutingModule } from './author-routing.module';
import { AuthorComponent } from './author.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap'
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AuthorComponent
  ],
  imports: [
    SharedModule,
    AuthorRoutingModule,
    NgbDatepickerModule
  ]
})
export class AuthorModule { }
