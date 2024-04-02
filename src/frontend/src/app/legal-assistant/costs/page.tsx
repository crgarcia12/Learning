"use client";

import * as React from 'react';
import Box from '@mui/material/Box';
import Divider from '@mui/material/Divider';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Paper from '@mui/material/Paper';
import IconButton from '@mui/material/IconButton';
import Tooltip from '@mui/material/Tooltip';
import ArrowRight from '@mui/icons-material/ArrowRight';
import KeyboardArrowDown from '@mui/icons-material/KeyboardArrowDown';
import Home from '@mui/icons-material/Home';
import Settings from '@mui/icons-material/Settings';
import People from '@mui/icons-material/People';
import PermMedia from '@mui/icons-material/PermMedia';
import Public from '@mui/icons-material/Public';
import HandshakeTwoToneIcon from '@mui/icons-material/HandshakeTwoTone';
import WorkspacePremiumTwoToneIcon from '@mui/icons-material/WorkspacePremiumTwoTone';
import { styled } from '@mui/material/styles';
import { green, pink } from '@mui/material/colors';

const data = [
  { icon: <HandshakeTwoToneIcon />, label: 'Bank vs Mrs Peters - Settled - chf 1.5M - 1 year' },
  { icon: <WorkspacePremiumTwoToneIcon  sx={{ color: green[500] }}  />, label: 'Bank vs Mr Pertussi - Won - chf0 - 4 years' },
  { icon: <Public sx={{ color: pink[500] }} />, label: 'Bank vs Governnent - Public Case - chf 3.7M - 10 years' },
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

export default function CostList() {
  const [open, setOpen] = React.useState(true);
  console.log(`[LegalAssistant] Rendering.`);

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
              primary="Economy of similar cases" 
              primaryTypographyProps={{
                fontSize: 15,
                fontWeight: 'medium',
                lineHeight: '20px',
                mb: '2px',
              }}
              secondary="Cost of similar cases in the past"
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
          {open &&
            data.map((item) => (
              <ListItemButton
                key={item.label}
                sx={{ py: 0, minHeight: 32, color: 'rgba(255,255,255,.8)' }}
              >
                <ListItemIcon sx={{ color: 'inherit' }}>
                  {item.icon}
                </ListItemIcon>
                <ListItemText
                  primary={item.label}
                  primaryTypographyProps={{ fontSize: 14, fontWeight: 'medium' }}
                />
              </ListItemButton>
            ))}
        </Box>
      </FireNav>
    </Box>
  );
}