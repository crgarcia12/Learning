"use client";

import * as React from 'react';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Public from '@mui/icons-material/Public';
import KeyboardArrowDown from '@mui/icons-material/KeyboardArrowDown';
import HandshakeTwoToneIcon from '@mui/icons-material/HandshakeTwoTone';
import WorkspacePremiumTwoToneIcon from '@mui/icons-material/WorkspacePremiumTwoTone';
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';

const data = [
  { icon: <HandshakeTwoToneIcon />, label: 'Bank vs Mrs Peters - Settled - chf 1.5M - 1 year' },
  { icon: <WorkspacePremiumTwoToneIcon />, label: 'Bank vs Mr Pertussi - Won - chf0 - 4 years' },
  { icon: <Public />, label: 'Bank vs Governnent - Public Case - chf 3.7M - 10 years' },
];

const FireNav = styled(List)<{ component?: React.ElementType }>({
  '& .MuiListItemButton-root': {
    paddingLeft: 24,
    paddingRight: 24,
  },
  '& .MuiListItemIcon-root': {
    minWidth: 0,
    marginRight: 16,
  },
  '& .MuiSvgIcon-root': {
    fontSize: 20,
  },
});

export default function Chat() {
  const [open, setOpen] = React.useState(true);

  return (
<Box sx={{ display: 'flex' }}>
      <FireNav component="nav" disablePadding>
        <Box
          sx={{
            //bgcolor: open ? 'rgba(71, 98, 130, 0.2)' : null,
            //pb: open ? 2 : 0,
          }}
        >
          <ListItemButton
            alignItems="flex-start"
            onClick={() => setOpen(!open)}
            sx={{
              px: 3,
              pt: 2.5,
              pb: open ? 0 : 2.5,
              '&:hover, &:focus': { '& svg': { opacity: open ? 1 : 0 } },
            }}
          >
            <ListItemText
              primary="Tips"
              primaryTypographyProps={{
                fontSize: 15,
                fontWeight: 'medium',
                lineHeight: '20px',
                mb: '2px',
              }}
              secondary="Tips on how to reply"
              secondaryTypographyProps={{
                noWrap: true,
                fontSize: 12,
                lineHeight: '16px',
                color: open ? 'rgba(0,0,0,0)' : 'rgba(255,255,255,0.5)',
              }}
              sx={{ my: 0 }}
            />
            <KeyboardArrowDown
              sx={{
                mr: -1,
                opacity: 0,
                transform: open ? 'rotate(-180deg)' : 'rotate(0)',
                transition: '0.2s',
              }}
            />
          </ListItemButton>
          {open && (

            <Paper>
              Consider sicking more information regarding the impact of a brand new law released a month ago on customer rights.
              
            </Paper>
          
          
          )}
        </Box>
      </FireNav>
    </Box>    
  );
}