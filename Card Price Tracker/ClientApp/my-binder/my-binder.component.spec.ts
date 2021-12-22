/// <reference path="../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MyBinderComponent } from './my-binder.component';

let component: MyBinderComponent;
let fixture: ComponentFixture<MyBinderComponent>;

describe('MyBinder component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MyBinderComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MyBinderComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});