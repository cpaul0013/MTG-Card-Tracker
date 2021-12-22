/// <reference path="../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { WantCardsComponent } from './want-cards.component';

let component: WantCardsComponent;
let fixture: ComponentFixture<WantCardsComponent>;

describe('WantCards component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ WantCardsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(WantCardsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});