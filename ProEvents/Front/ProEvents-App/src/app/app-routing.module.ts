import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { EventsComponent } from './components/events/events.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { EventsDetailsComponent } from './components/events/events-details/events-details.component';
import { EventsListComponent } from './components/events/events-list/events-list.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

const routes: Routes = [
  {
    path: 'user',
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ],
  },
  { path: 'profile', component: ProfileComponent },
  { path: 'events', redirectTo: 'events/list' },
  {
    path: 'events',
    component: EventsComponent,
    children: [
      { path: 'details/:id', component: EventsDetailsComponent },
      { path: 'details', component: EventsDetailsComponent },
      { path: 'list', component: EventsListComponent },
    ],
  },
  { path: 'speakers', component: SpeakersComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'profile', component: ProfileComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
