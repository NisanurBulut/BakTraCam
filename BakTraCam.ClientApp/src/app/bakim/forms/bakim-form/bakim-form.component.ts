import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-bakim-form',
  templateUrl: './bakim-form.component.html',
  styleUrls: ['./bakim-form.component.css']
})
export class BakimFormComponent implements OnInit {

  private bakimId = 0;
  form: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

}
