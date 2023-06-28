import { Injectable } from '@angular/core';
import { Cloudinary, CloudinaryImage } from '@cloudinary/url-gen';

@Injectable({
  providedIn: 'root'
})
export class CloudinaryService {

  img!: CloudinaryImage;

  constructor() {
    this.getCloudinaryInstance()
  }

  getImage(imagePubId: string) {
    this.img = this.getCloudinaryInstance().image(imagePubId);
  }

  getCloudinaryInstance(): Cloudinary {
    const cloudName = 'godwin4real';
    return new Cloudinary({
      cloud: {
        cloudName
      },
      url: {
        cname: 'www.quick-shoppy.com',
        forceVersion: true
      }
    });
  }

  uploadImage() {
    // const widget = cloudinary.createUploadWidget({})
  }
}
