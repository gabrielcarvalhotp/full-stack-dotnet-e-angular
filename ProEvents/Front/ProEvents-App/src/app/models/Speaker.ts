import { SocialMedia } from './SocialMedia';

export interface Speaker {
  id: number;
  name: string;
  miniCurriculum: string;
  imageURL: string;
  phone: string;
  email: string;
  socialMedias: SocialMedia[];
  events: Event[];
}
