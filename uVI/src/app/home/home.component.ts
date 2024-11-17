import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';  // Import RouterModule

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterModule],  // Add RouterModule here
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']  // Fix the styleUrl to styleUrls
})
export class HomeComponent {
  appName = 'VaxTrack';
  appDescription = 'Launching VaxTrack v2, as an open source platform for India to operate successful vaccination with efficient monitoring with an aim of achieving win over Covid-19.';
}
