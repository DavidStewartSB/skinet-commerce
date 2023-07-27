import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  @ViewChild('mobileMenu') mobileMenu!: ElementRef;
  @ViewChild('dropdownUser') dropdownUser!: ElementRef;

  constructor() { }

  ngOnInit(): void {
  }


  toggleMobileMenu() {
    this.mobileMenu.nativeElement.classList.toggle('hidden');
  }

  toggleDropdown() {
    this.dropdownUser.nativeElement.classList.toggle('hidden');
  }
}
