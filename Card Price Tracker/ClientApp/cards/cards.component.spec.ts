/// <reference path="../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CardsComponent } from './cards.component';

let component: CardsComponent;
let fixture: ComponentFixture<CardsComponent>;

describe('Cards component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CardsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CardsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});