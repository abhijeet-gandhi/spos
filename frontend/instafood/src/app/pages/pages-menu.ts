import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Dashboard',
    icon: 'home-outline',
    link: '/pages/dashboard',
    home: true,
  },
  {
    title: 'FEATURES',
    group: true,
  },
  {
    title: 'Menu',
    icon: 'book-open-outline',
    link: '/pages/menu',
  },
  {
    title: 'Order',
    icon: 'plus-outline',
    link: '/pages/order',
  },
  {
    title: 'Auth',
    icon: 'lock-outline',
    children: [
      {
        title: 'Login',
        link: '/pages/auth/login',
      },
      {
        title: 'Register',
        link: '/pages/auth/register',
      },
    ],
  },
];
