import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Doctor } from './doctor';

@Component({
  selector: 'app-test',
  templateUrl: './app.component.html',
  providers: [DataService]
})
export class AppComponent implements OnInit {
  title = 'app';
  doctor: Doctor = new Doctor();
  doctors: [Doctor];
  tableMode: boolean = true;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadDoctors();
  }

  loadDoctors() {
    this.dataService.getDoctors()
      .subscribe((data: [Doctor]) => this.doctors = data);
  }
}
