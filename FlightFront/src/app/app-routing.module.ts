import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './Pages/index/index.component';
import { FlightsResultsComponent } from './Pages/flights-results/flights-results.component';

const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' },
  {path : 'index', title : 'Index', component : IndexComponent},
  {path : 'flights-results', title : 'Results', component : FlightsResultsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
