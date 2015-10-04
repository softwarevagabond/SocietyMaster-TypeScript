module SocietyMaster {

  export  interface ISocietyRegisterStep1Model {
        Name: string;
        Description: string;
        Address: string;
        Locality: string;
        City: string;
        State: string;
        ZipCode: string;
        Initialized: boolean;
        Errors: string[];
        IsValid: boolean;
       
    }

  export  class SocietyRegisterStep1Model implements ISocietyRegisterStep1Model {
        Name: string;
        Description: string;
        Address: string;
        Locality: string;
        City: string;
        State: string;
        ZipCode: string;
        Initialized: boolean;
        Errors: string[];
        IsValid: boolean;

        constructor() {
            this.Name = '';
            this.Description = '';
            this.Address = '';
            this.Locality = '';
            this.City = '';
            this.State = '';
            this.ZipCode = '';
            this.Initialized = false;
            this.Errors = [];
            this.IsValid = true;
        }
    }

   export interface ISocietyRegisterStep2Model {
        Name: string;   
        Initialized: boolean;    
    }

   export class SocietyRegisterStep2Model implements ISocietyRegisterStep2Model {
        Name: string;
       Initialized: boolean;

       constructor() {
           this.Name = '';
            this.Initialized = false;
        }
    }
} 