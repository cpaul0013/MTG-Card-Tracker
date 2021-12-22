/// <reference path="../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SellCardComponent } from './sell-card.component';

let component: SellCardComponent;
let fixture: ComponentFixture<SellCardComponent>;

describe('SellCard component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SellCardComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SellCardComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});