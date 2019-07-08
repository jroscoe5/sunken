import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GameComponent } from './game/game.component';

import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatButtonModule} from '@angular/material/button';
import { CharacterComponent } from './character/character.component';

@NgModule({
  declarations: [
    AppComponent,
    GameComponent,
    CharacterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DragDropModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
