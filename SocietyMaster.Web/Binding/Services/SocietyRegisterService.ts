//ToDO: Get more of the functionality moved from the ViewModel to the service
module SocietyMaster {
    export interface ISocietyRegisterService {

        societyRegisterStep1Model: SocietyMaster.ISocietyRegisterStep1Model;
        societyRegisterStep2Model: SocietyMaster.ISocietyRegisterStep2Model;

        setRegisterStep1Model(societyRegisterStep1Model: SocietyMaster.ISocietyRegisterStep1Model): void;
        setRegisterStep2Model(societyRegisterStep2Model: SocietyMaster.ISocietyRegisterStep2Model): void;

        getRegisterStep1Model(): SocietyMaster.ISocietyRegisterStep1Model;
        getRegisterStep2Model(): SocietyMaster.ISocietyRegisterStep2Model;
    }

    export class SocietyRegisterService implements ISocietyRegisterService {
        societyRegisterStep1Model: SocietyMaster.ISocietyRegisterStep1Model;
        societyRegisterStep2Model: SocietyMaster.ISocietyRegisterStep2Model;

        constructor() {
            this.societyRegisterStep1Model = new SocietyMaster.SocietyRegisterStep1Model();
            this.societyRegisterStep2Model = new SocietyMaster.SocietyRegisterStep2Model();
        }

        setRegisterStep1Model(societyRegisterStep1Model: SocietyMaster.ISocietyRegisterStep1Model): void {
            this.societyRegisterStep1Model = societyRegisterStep1Model;
        }
        setRegisterStep2Model(societyRegisterStep2Model: SocietyMaster.ISocietyRegisterStep2Model): void {
            this.societyRegisterStep2Model = societyRegisterStep2Model;
        }

        getRegisterStep1Model(): SocietyMaster.ISocietyRegisterStep1Model {
            return this.societyRegisterStep1Model;
        }
        getRegisterStep2Model(): SocietyMaster.ISocietyRegisterStep2Model {
            return this.societyRegisterStep2Model;
        }
    }
    //Todo: May be ceate a new module if needed...
    angular.module('common').service('societyRegisterService', SocietyRegisterService);
} 