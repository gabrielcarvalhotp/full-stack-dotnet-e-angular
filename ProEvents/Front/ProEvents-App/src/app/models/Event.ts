import { Batch } from './Batch';
import { SocialMedia } from './SocialMedia';
import { Speaker } from './Speaker';

export interface Event {
  id: number;
  location: string;
  eventDate?: Date;
  theme: string;
  numberPeople: number;
  imageURL: string;
  phone: string;
  email: string;
  batches: Batch[];
  socialMedias: SocialMedia[];
  speakers: Speaker[];
  createdAt: Date;
}
