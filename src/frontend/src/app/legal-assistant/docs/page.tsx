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
import ListSubheader from '@mui/material/ListSubheader';
import FolderIcon from '@mui/icons-material/Folder';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import Collapse from '@mui/material/Collapse';
import StarBorder from '@mui/icons-material/StarBorder';

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

export default function RelevantDocumentList() {
  const [open, setOpen] = React.useState(true);
  console.log(`[LegalAssistant] Rendering.`);

  const [courtCasesOpen, setCourtCasesOpen] = React.useState(true);
  const courtCasesOpenHandleClick = () => {
    setCourtCasesOpen(!courtCasesOpen);
  };

  const [lawOpen, setLawOpen] = React.useState(true);
  const LawOpenHandleClick = () => {
    setLawOpen(!lawOpen);
  };


  return (
    <Box sx={{ display: 'flex' }}>
      <FireNav component="nav" disablePadding>
        <Box
          sx={{
            bgcolor: open ? 'rgba(71, 98, 130, 0.2)' : null,
            pb: open ? 2 : 0,
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
              primary="Relevant files"
              primaryTypographyProps={{
                fontSize: 15,
                fontWeight: 'medium',
                lineHeight: '20px',
                mb: '2px',
              }}
              secondary="Files that might be relevant to your case."
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
            <Box>
              <List
                sx={{ bgcolor: 'background.paper', textAlign: 'left' }}
                component="nav"
                aria-labelledby="nested-list-subheader"
              >
                 {/* Court cases */}
                <List>
                  <ListItemButton onClick={courtCasesOpenHandleClick}>
                    <ListItemIcon>
                      <FolderIcon />
                    </ListItemIcon>
                    <ListItemText primary="Court cases" />
                    {courtCasesOpen ? <ExpandLess /> : <ExpandMore />}
                  </ListItemButton>
                  <Collapse in={courtCasesOpen} timeout="auto" unmountOnExit>
                    <List component="div" disablePadding>
                      <ListItemButton>
                        <ListItemIcon>
                          <img src="/static/icons/docs.png" height={20} width={20} />
                        </ListItemIcon>
                        <ListItemText primary="[Ongoing] Bank vs other bank in France legal case" />
                      </ListItemButton>
                      <ListItemButton>
                        <ListItemIcon>
                          <img src="/static/icons/pdf.png" height={20} width={20} />
                        </ListItemIcon>
                        <ListItemText primary="[Closed] Mr Pertussi vs Bank court decision" />
                      </ListItemButton>
                    </List>
                  </Collapse>
                </List>
                {/* Laws */}
                <List>
                  <ListItemButton onClick={LawOpenHandleClick}>
                    <ListItemIcon>
                      <FolderIcon />
                    </ListItemIcon>
                    <ListItemText primary="Law" />
                    {lawOpen ? <ExpandLess /> : <ExpandMore />}
                  </ListItemButton>
                  <Collapse in={lawOpen} timeout="auto" unmountOnExit>
                    <List component="div" disablePadding>
                      <ListItemButton>
                        <ListItemIcon>
                          <img src="/static/icons/edge.png" height={20} width={20} />
                        </ListItemIcon>
                        <ListItemText primary="Law on credit cards claims" />
                      </ListItemButton>
                      <ListItemButton>
                        <ListItemIcon>
                          <img src="/static/icons/edge.png" height={20} width={20} />
                        </ListItemIcon>
                        <ListItemText primary="Consumer rights" />
                      </ListItemButton>
                    </List>
                  </Collapse>
                </List>
              </List>
            </Box>
          )}
        </Box>
      </FireNav>
    </Box>
  );
}