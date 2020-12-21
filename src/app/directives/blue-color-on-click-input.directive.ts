import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHighlightBlueInput]'
})
export class BlueColorOnClickInputDirective {

  constructor(private elemRef:ElementRef) { }

  @HostListener('focus') onFocus(){
    this.highlight('#1E90FF')
  }

  @HostListener('focusout')onFocusOut(){
    this.highlight(null);
  }

  private highlight(color:string){
    this.elemRef.nativeElement.style.border = 2;
    this.elemRef.nativeElement.style.borderColor = color;
  }

}
