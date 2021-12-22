/// <reference path="../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CardDetailsComponent } from './card-details.component';

let component: CardDetailsComponent;
let fixture: ComponentFixture<CardDetailsComponent>;

describe('CardDetails component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CardDetailsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CardDetailsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});