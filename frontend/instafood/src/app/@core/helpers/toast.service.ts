import { Injectable } from '@angular/core';
import { NbComponentStatus, NbGlobalPhysicalPosition, NbGlobalPosition, NbToastrService } from '@nebular/theme';

@Injectable()
export class ToastService {
    destroyByClick = true;
    duration = 2000;
    hasIcon = true;
    position: NbGlobalPosition = NbGlobalPhysicalPosition.TOP_RIGHT;
    preventDuplicates = false;

    constructor(private toastrService: NbToastrService) {

    }

    showSuccess(title: string, body: string) {
        this.showToast("success", title, body);
    }

    showError(title: string, body: string) {
        this.showToast("danger", title, body);
    }

    private showToast(type: NbComponentStatus, title: string, body: string) {
        const config = {
            status: type,
            destroyByClick: this.destroyByClick,
            duration: this.duration,
            hasIcon: this.hasIcon,
            position: this.position,
            preventDuplicates: this.preventDuplicates,
        };
        const titleContent = title;

        this.toastrService.show(
            body,
            titleContent,
            config);
    }

}