import {Location} from '@angular/common';
export class ApiRootConfig {
    rootUrl: string = "";
}

export class GenerateApiRootConfig extends ApiRootConfig {
    /**
     *
     */
    constructor(
    ) {
        super();
        this.rootUrl = Location.stripTrailingSlash(document.getElementsByTagName('base')[0].href);
    }
    
}